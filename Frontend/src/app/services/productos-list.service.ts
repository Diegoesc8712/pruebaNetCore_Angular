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

export class ProductoService {
  AUTH_SERVER: string = 'https://localhost:7262';
  constructor(private http: HttpClient) {}

  productosLista():Observable<Producto[]>{
    return this.http.get<Producto[]>(`${this.AUTH_SERVER}/Inventario`)
  }

  
}