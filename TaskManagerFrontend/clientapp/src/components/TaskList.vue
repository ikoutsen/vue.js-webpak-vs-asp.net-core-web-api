<template>
    <div v-if="tasks">
        <h4>Фильтр:</h4>
        <div class="row align-items-center">
            <div class="col text-end">
                <label class="col-form-label">Дата создания</label>
            </div>
            <div class="col">
                <input type="date" class="form-control" v-model="taskFilterQuery.creatingDate" />
            </div>

            <div class="col text-end">
                <label class="col-form-label">Состояние</label>
            </div>
            <div class="col">
                <select class="form-control" required v-model="taskFilterQuery.taskStateId">
                    <option v-for="taskState in taskStates" v-bind:value="taskState.id">{{taskState.name}}</option>
                </select>
            </div>
            <div class="col text-end">
                <label class="col-form-label">Исполнитель</label>
            </div>
            <div class="col">
                <select class="form-control" required v-model="taskFilterQuery.creatorUserId">
                    <option v-for="user in filteredUsers" v-bind:value="user.id">{{user.name}}</option>
                </select>
            </div>
            <div class="col">
                <button class="btn btn-info" @click="clearFilter">Очистить</button>
            </div>
        </div>

        <table class="table">
            <thead>
                <TaskListHeader></TaskListHeader>
            </thead>
            <tbody>
                <TaskListRow v-for="task in filteredTasks" :key="task.id" :task="task"></TaskListRow>
            </tbody>
        </table>
        <div>
            <router-link to="/new" class="btn btn-primary">Добавить</router-link>
        </div>
    </div>
</template>

<script>
    import TaskListHeader from './TaskListHeader.vue'
    import TaskListRow from './TaskListRow.vue'
    import TasksDataService from '../services/tasks-data-service';
    import TaskStateDataService from '../services/taskstates-data-service';
    import moment from 'moment';

    export default {
        name: "TaskList",
        components: {
            TaskListHeader,
            TaskListRow
        },
        data() {
            return {
                taskFilterQuery: {
                    creatingDate: null,
                    taskStateId: null,
                    creatorUserId: null
                },
                tasks: null,
                taskStates: null
            };
        },
        methods: {
            loadtaskStates() {
                TaskStateDataService.getAll()
                    .then(rs => {
                        this.taskStates = rs.data;
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },
            loadtasks() {
                TasksDataService.getAll()
                    .then(rs => {
                        this.tasks = rs.data;
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },
            clearFilter() {
                this.taskFilterQuery.creatingDate = null;
                this.taskFilterQuery.taskStateId = null;
                this.taskFilterQuery.creatorUserId = null;
            },
            format: function (date) {
                if (date)
                    return moment(String(date)).format('YYYY-MM-DD');
            }
        },
        mounted: function () {
            this.loadtaskStates();
            this.loadtasks();
        },
        computed: {
            filteredTasks() {
                let tasks = this.tasks;

                if (this.taskFilterQuery.creatingDate) {
                    tasks = tasks.filter((t) => {
                        return this.format(t.creatingDate) == this.format(this.taskFilterQuery.creatingDate);
                    });
                }
                if (this.taskFilterQuery.taskStateId) {
                    tasks = tasks.filter((t) => {
                        return t.taskStateId == this.taskFilterQuery.taskStateId;
                    });
                }
                if (this.taskFilterQuery.creatorUserId) {
                    tasks = tasks.filter((t) => {
                        return t.creatorUserId == this.taskFilterQuery.creatorUserId;
                    });
                }

                return tasks;
            },
            filteredUsers() {
                return this.filteredTasks.map(t => t.creatorUser);
            }
        }
    };
</script>
