<template>
    <div id="app">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <span class="navbar-brand">TaskManager</span>
        </nav>
        <div class="container body-content">
            <router-view />
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                name: "app"
            };
        },
    };
</script>
