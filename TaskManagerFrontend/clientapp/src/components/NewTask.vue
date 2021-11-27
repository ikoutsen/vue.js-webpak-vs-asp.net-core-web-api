<template>
    <div>
        <h1 class="h1">Новая задача</h1>
        <form class="submit-form" @submit.prevent="saveTask">
            <div v-if="editable">
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
                    <button type="submit" class="btn btn-primary">Добавить</button>
                    <a class="btn btn-success" v-bind:href="'/tasks'">Назад</a>
                </div>
            </div>
            <div v-else>
                <h4>Запись добавлена</h4>
                <div>
                    <a class="btn btn-success" v-bind:href="'/tasks'">Назад</a>
                </div>
            </div>
        </form>
    </div>
</template>

<script>
    import TasksDataService from '../services/tasks-data-service';
    import TaskStatesDataService from '../services/taskstates-data-service';
    import UsersDataService from '../services/users-data-service';

    export default {
        data() {
            return {
                editable: true,
                task: {
                    descrition: '',
                    creatingDate: null,
                    creatorUserId: null,
                    taskStateId: null,
                    workerUserId: null
                },
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
            saveTask() {
                TasksDataService.create(this.task)
                    .then(response => {
                        this.editable = false;
                    })
                    .catch(e => {
                        console.log(e);
                    });
            }
        },
        mounted: function () {
            this.loadTaskStates();
            this.loadUsers();
        }
    };
</script>
