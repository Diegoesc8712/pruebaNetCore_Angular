import { Injectable } from '@angular/core';
import { Producto } from '../models/productos';

@Injectable({
  providedIn: 'root'
})
export class CarritoService {
  carrito: Producto[] = [];

  agregarProducto(producto: Producto) {
    this.carrito.push(producto);
  }

  eliminarProducto(producto: Producto) {
    const index = this.carrito.indexOf(producto);
    this.carrito.splice(index, 1);
  }

  obtenerCarrito() {
    return this.carrito;
  }

 
}
