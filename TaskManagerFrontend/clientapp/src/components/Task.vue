<template>
    <div v-if="task">
        <form class="edit-form" @submit.prevent="updateTask">
            <div class="form-group">
                <label>Дата создания</label>
                <input type="date" class="form-control" required v-model="task.creatingDate" />
            </div>
            <div class="form-group">
                <label>Описание</label>
                <input type="text" class="form-control" required v-model="task.description" />
            </div>
            <div class="form-group">
                <label>Инициатор</label>
                <select class="form-control" required v-model="task.creatorUserId">
                    <option v-for="user in users" v-bind:value="user.id">{{user.name}}</option>
                </select>
            </div>
            <div class="form-group">
                <label>Состояние</label>
                <select class="form-control" required v-model="task.taskStateId">
                    <option v-for="taskState in taskStates" v-bind:value="taskState.id">{{taskState.name}}</option>
                </select>
            </div>
            <div class="form-group">
                <label>Исполнитель</label>
                <select class="form-control" v-model="task.workerUserId">
                    <option v-for="user in users" v-bind:value="user.id">{{user.name}}</option>
                </select>
            </div>
            <div class="form-group">
                <button type="submit" class="btn btn-warning">Изменить</button>
                <button class="btn btn-danger" @click="deleteTask">Удалить</button>
                <a class="btn btn-success" v-bind:href="'/tasks'">Назад</a>
            </div>
        </form>
    </div>
</template>

<script>
    import TasksDataService from '../services/tasks-data-service';
    import TaskStatesDataService from '../services/taskstates-data-service';
    import UsersDataService from '../services/users-data-service';
    import moment from 'moment';

    export default {
        data() {
            return {
                task: null,
                taskStates: null,
                users: null
            }
        },
        methods: {
            loadTaskStates() {
                TaskStatesDataService.getAll()
                    .then(rs => {
                        this.taskStates = rs.data;
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },
            loadUsers() {
                UsersDataService.getAll()
                    .then(rs => {
                        this.users = rs.data;
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },
            loadTasks(id) {
                TasksDataService.get(id)
                    .then(rs => {
                        rs.data.creatingDate = this.format(rs.data.creatingDate);
                        this.task = rs.data;
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },
            updateTask() {
                TasksDataService.update(this.task)
                    .then(response => {
                        this.$router.push({
                            name: "tasks"
                        });
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },
            deleteTask() {
                TasksDataService.delete(this.task)
                    .then(response => {
                        this.$router.push({
                            name: "tasks"
                        });
                    })
                    .catch(e => {
                        console.log(e);
                    });
            },
            format: function (date) {
                if (date)
                    return moment(String(date)).format('YYYY-MM-DD');
            }
        },
        mounted: function () {
            this.loadTaskStates();
            this.loadUsers();
            this.loadTasks(this.$route.params.id);
        }
    };
</script>
