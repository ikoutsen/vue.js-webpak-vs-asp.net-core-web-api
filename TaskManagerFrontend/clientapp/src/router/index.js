import Vue from 'vue';
import Router from 'vue-router';

import TaskList from '../components/TaskList.vue'
import Task from '../components/Task.vue'
import NewTask from '../components/NewTask.vue'

Vue.use(Router);

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/tasks',
            name: 'tasks',
            component: TaskList
        },
        {
            path: '/tasks/:id',
            name: 'task',
            component: Task
        },
        {
            path: '/new',
            name: 'newtask',
            component: NewTask
        }
    ]
});