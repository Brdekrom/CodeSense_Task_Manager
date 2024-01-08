import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/interfaces/emloyee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeClientService {

  private apiUrl = 'http://localhost:7014/api/employee'; // Update this URL

  constructor(private http: HttpClient) { }

  getUsers(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }

  getUser(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${id}`);
  }

  createUser(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(this.apiUrl, employee);
  }

  updateUser(id: number, employee: Employee): Observable<Employee> {
    return this.http.put<Employee>(`${this.apiUrl}/${id}`, employee);
  }

  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
