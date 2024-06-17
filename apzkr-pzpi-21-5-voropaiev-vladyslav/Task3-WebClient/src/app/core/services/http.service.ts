import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from '../../../environments/environment.development';

/**
 * Service to handle HTTP requests.
 */
@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  /**
   * Sends a GET request to the specified URL.
   * @param {string} url - The URL to send the request to.
   * @returns {Observable<T>} - The response from the server.
   */
  get<T>(url: string): Observable<T> {
    return this.httpClient.get<T>(this.buildUrl(url), this.getHeaders()).pipe(catchError(this.handleError));
  }

  /**
   * Sends a POST request to the specified URL.
   * @param {string} url - The URL to send the request to.
   * @param {unknown} resource - The body of the request.
   * @returns {Observable<T>} - The response from the server.
   */
  post<T>(url: string, resource: unknown) {
    return this.httpClient.post<T>(this.buildUrl(url), resource, this.getHeaders()).pipe(catchError(this.handleError));
  }

  /**
   * Sends a DELETE request to the specified URL.
   * @param {string} url - The URL to send the request to.
   * @returns {Observable<void>} - The response from the server.
   */
  delete(url: string) {
    return this.httpClient.delete(`${this.buildUrl(url)}`, this.getHeaders()).pipe(catchError(this.handleError));
  }

  /**
   * Sends a PUT request to the specified URL.
   * @param {string} url - The URL to send the request to.
   * @param {T} resource - The body of the request.
   * @returns {Observable<T>} - The response from the server.
   */
  put<T>(url: string, resource: T) {
    return this.httpClient.put<T>(this.buildUrl(url), resource, this.getHeaders()).pipe(catchError(this.handleError));
  }

  /**
   * Handles errors from HTTP requests.
   * @param {HttpErrorResponse} err - The error from the HTTP request.
   * @returns {Observable<never>} - An observable that throws the error.
   */
  private handleError(err: HttpErrorResponse) {
    return throwError(() => err);
  }

  /**
   * Builds the full URL for a request.
   * @param {string} url - The endpoint of the request.
   * @returns {string} - The full URL for the request.
   */
  private buildUrl(url: string): string {
    return this.baseUrl + url;
  }

  /**
   * Gets the headers for a request.
   * @returns {{ headers?: HttpHeaders }} - The headers for the request.
   */
  private getHeaders(): { headers?: HttpHeaders } {
    const token = localStorage.getItem('token');
    if (token) {
      const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
      });
      return { headers };
    }
    return {};
  }
}