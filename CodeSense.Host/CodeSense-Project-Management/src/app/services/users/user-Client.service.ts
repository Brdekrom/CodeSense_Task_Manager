import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { User } from '../../interfaces/user';
import { CreateUserRequest } from 'src/app/interfaces/messages/create-user-request';

@Injectable({
  providedIn: 'root'
})
export class UserClientService {

  private apiUrl = 'http://localhost:5007/api/authentication'; // Update this URL

  constructor(private http: HttpClient) { }

  // Get all users
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }

  // Get user by ID
  getUser(id: number): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/${id}`);
  }

  // Create new user
  //
  createUser(createUser: CreateUserRequest): Observable<number> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    return this.http.post<number>(`${this.apiUrl}/register`, createUser, httpOptions)
    .pipe(
        tap(response => console.log('HTTP response', response)),
        catchError(this.handleError)
    );
  }

  // Update user
  updateUser(id: number, user: User): Observable<User> {
    return this.http.put<User>(`${this.apiUrl}/${id}`, user);
  }

  // Delete user
  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  private handleError(error: HttpErrorResponse) {
    
    let errorMessage = 'An unknown error occurred.';
    if (error.error instanceof ErrorEvent) {
        errorMessage = `An error occurred: ${error.error.message}`;
    } else if (error.status === 400) {
        errorMessage = error.error.message || 'Email already linked to an user.';
    }
    return throwError(() => new Error(errorMessage));
}

}
