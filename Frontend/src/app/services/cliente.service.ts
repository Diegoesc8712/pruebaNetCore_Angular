import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { Producto } from '../models/productos';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { JwtResponseI } from './../models/jwt-response';
import { tap } from 'rxjs/operators';
import { Token } from '@angular/compiler';



@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  AUTH_SERVER: string = 'https://localhost:7262';
  constructor(private http: HttpClient) {}

  buscarCliente(celular: number){
    return this.http.get(`https://localhost:7262/Clientes/buscar/${celular}`);
  }
}
