import { ViewChildren, Component, OnInit, QueryList } from '@angular/core';
import { Producto } from '../models/productos';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { ProductoService } from '../services/productos-list.service';
import { HttpClient } from '@angular/common/http';
import { CarritoService } from '../services/carrito.service';

@Component({
  selector: 'app-productos-list',
  templateUrl: './productos-list.component.html',
  styleUrls: ['./productos-list.component.css']
})
export class ProductosListComponent {
  productos: Producto[] = [];
  seleccionado: Producto[] = [];
  carrito: Producto[] = [];

  constructor(private productoService: ProductoService, private router: Router, private carritoService: CarritoService){}

  ngOnInit(): void {
    debugger;
    this.productoService.productosLista().subscribe(productos => this.productos = productos);
}
  
  agregarAlCarrito() {
    // Aquí debería tener código para agregar el producto seleccionado al carrito
    console.log(this.seleccionado);
    this.productos.forEach((producto)=>{
      if(producto.selected) {
        this.carritoService.agregarProducto(producto);
        }
    });

    this.router.navigate(['/compras']);
  }

}
