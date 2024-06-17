import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpService) { }

  get() {
    return this.http.get<User[]>('users');
  }

  export() {
    return this.http.get<string>('users/export');
  }

  import(jsonContent: string) {
    return this.http.post('users/import', { jsonContent: jsonContent });
  }

  delete(id: string) {
      return this.http.delete(`users?userId=${id}`);
  }

  makeAdmin(id: string) {
      return this.http.post(`users/make-admin?userId=${id}`, {});
  }
}
