import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { UserToken } from '../models/userToken';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isAuthenticatedInterval: any;

  constructor(
      private http: HttpService,
      private router: Router) { }

  login(email: string, password: string) {
    this.http.post<string>('users/login', { login: email, password: password })
        .subscribe(
            (token: string) => {
              this.handleAuthentication(token);
            },
            (err) => {
              alert('Invalid email or password.');
            }
        );
  }

  handleAuthentication(token: string) {
    const decodedToken: UserToken = jwtDecode(token);
    console.log(jwtDecode(token));
    if (decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] !== 'Admin') {
        alert('You do not have permission to access this application.');
        return;
    }

    localStorage.setItem('token', token);
    localStorage.setItem('userName', decodedToken.name);
    localStorage.setItem('userEmail', decodedToken.email);

    this.router.navigate(['/users']).then(() => window.location.reload());
  }

  isAuthenticated() {
    const token = localStorage.getItem('token');

    if (token) {
      const decodedToken: UserToken = jwtDecode(token);
      return decodedToken.exp > Date.now() / 1000;
    }

    return false;
  }

  startAuthenticatedCheck() {
    if (this.isAuthenticatedInterval) {
      clearInterval(this.isAuthenticatedInterval);
    }

    this.isAuthenticatedInterval = setInterval(() => {
      if (!this.isAuthenticated()) {
        alert('Your session has expired. Please login again.');
        this.router.navigate(['/login']);
      }
    }, 60000);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userName');
    localStorage.removeItem('userEmail');

    this.router.navigate(['/login']).then(() => window.location.reload());
  }
}
