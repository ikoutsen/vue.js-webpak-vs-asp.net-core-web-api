import Vue from 'vue';
import App from './App.vue';
import router from './router'
import moment from 'moment';
import 'bootstrap/dist/css/bootstrap.min.css'

Vue.filter('dd.mm.yyyy', function (value) {
    if (value) {
        return moment(String(value)).format('DD.MM.YYYY');
    }
});

new Vue({
    el: '#app',
    router,
    render: h => h(App),
});