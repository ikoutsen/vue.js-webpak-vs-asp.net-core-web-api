<template>
    <tr>
        <td>{{ task.creatingDate | dd.mm.yyyy }}</td>
        <td>{{ task.description }}</td>
        <td>{{ task.creatorUser.name }}</td>
        <td>{{ task.taskState.name }}</td>
        <td v-if="task.workerUser">{{ task.workerUser.name }}</td>
        <td v-else></td>
        <td class="text-right">
            <router-link :to="{name: 'task', params: {id: task.id}}" class="text-dark">Изменить</router-link>
        </td>
    </tr>
</template>

<script>
    export default {
        name: "TaskListRow",
        props: {
            task: {
                type: Object,
                required: true
            }
        }
    };
</script>
