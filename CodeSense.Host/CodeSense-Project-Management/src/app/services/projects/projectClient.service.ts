import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Project } from 'src/app/interfaces/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectClientService {

  private apiUrl = 'http://localhost:3000/project'; // Update this URL

  constructor(private http: HttpClient) { }

  getUsers(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl);
  }

  getUser(id: number): Observable<Project> {
    return this.http.get<Project>(`${this.apiUrl}/${id}`);
  }

  createUser(project: Project): Observable<Project> {
    return this.http.post<Project>(this.apiUrl, project);
  }

  updateUser(id: number, project: Project): Observable<Project> {
    return this.http.put<Project>(`${this.apiUrl}/${id}`, project);
  }

  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
