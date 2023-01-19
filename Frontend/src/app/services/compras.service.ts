import { Injectable } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { Producto } from '../models/productos';
import { compras } from '../models/compras';
import { Observable } from 'rxjs';
import { JwtResponseI } from './../models/jwt-response';
import { tap } from 'rxjs/operators';
import { Token } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class ComprasService {
  AUTH_SERVER: string = 'https://localhost:7262';
  constructor(private http: HttpClient) {}
  crearCompra(compra: any):Observable<compras[]>{
    debugger;
    return this.http.post<compras[]>('https://localhost:7262/compras/nuevo', compra);
  }


}
