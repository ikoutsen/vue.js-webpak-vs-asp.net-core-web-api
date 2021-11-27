import http from '../http-common';

class TaskStatesDataService {
    getAll() {
        return http.get('/taskstates');
    }
    get(id) {
        return http.get(`/taskstates/${id}`);
    }
    create(data) {
        return http.post('/taskstates', data);
    }
    update(data) {
        return http.put('/taskstates', data);
    }
    delete(data) {
        return http.delete('/taskstates', data);
    }
}

export default new TaskStatesDataService();