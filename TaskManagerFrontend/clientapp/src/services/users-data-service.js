import http from '../http-common';

class UsersDataService {
    getAll() {
        return http.get('/users');
    }
    get(id) {
        return http.get(`/users/${id}`);
    }
    create(data) {
        return http.post('/users', data);
    }
    update(data) {
        return http.put('/users', data);
    }
    delete(data) {
        return http.delete('/users', data);
    }
}

export default new UsersDataService();