import http from '../http-common';

class TasksDataService {
    getAll() {
        return http.get('/tasks');
    }
    get(id) {
        return http.get(`/tasks/${id}`);
    }
    create(data) {
        return http.post('/tasks', data);
    }
    update(data) {
        return http.put('/tasks', data);
    }
    delete(data) {
        return http.delete('/tasks', { data: data });
    }
}

export default new TasksDataService();