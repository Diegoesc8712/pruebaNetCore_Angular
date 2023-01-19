import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserI } from '../models/user';
import { JwtResponseI } from './../models/jwt-response';
import { tap } from 'rxjs/operators';
import { Observable, BehaviorSubject } from 'rxjs'; 
import { Token } from '@angular/compiler';
import { Usuario } from '../models/usuario';


@Injectable({
  providedIn: 'root'
})
export class UsuariosListService {
  AUTH_SERVER: string = 'https://localhost:7262';
  constructor(private http: HttpClient) { }

  usuariosLista():Observable<Usuario[]>{
    return this.http.get<Usuario[]>(`${this.AUTH_SERVER}/Usuarios`)
  }
}
