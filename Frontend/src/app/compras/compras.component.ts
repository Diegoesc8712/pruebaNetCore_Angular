import { Component } from '@angular/core';
import { CarritoService } from '../services/carrito.service';
import { compras } from '../models/compras';
import { items } from '../models/items';
import { ClienteService } from '../services/cliente.service';
import { Producto } from '../models/productos';
import { ComprasService } from '../services/compras.service';

@Component({
  selector: 'app-compras',
  templateUrl: './compras.component.html',
  styleUrls: ['./compras.component.css']
})
export class ComprasComponent {
    ordenCompra: string = "";
    fechaCompra: string = "";
    nombreCliente: string = "";
    medioPago: string= "";
    celular: number = 0;
    cliente: any;
    valorCompra: number = 0;
    cargando: boolean = false;
    clienteEncontrado: boolean = false;
    productosCarrito: Producto[] = [];
  
  constructor(
      private carritoService: CarritoService, 
      private clienteService: ClienteService, 
      private ComprasService: ComprasService) {
    this.productosCarrito = this.carritoService.obtenerCarrito();
  }
  
  realizarCompra(){
    debugger;
    let compra = {
      ordenCompra: this.ordenCompra,
      fechaCompra: this.fechaCompra,
      valorCompra: this.valorCompra,
      medioPago: this.medioPago,
      clienteId: this.cliente[0].id
  };
  this.ComprasService.crearCompra(compra).subscribe(compraCreada => {
    debugger;
      console.log(compraCreada);
  });
  }
  buscarCliente() {
    debugger;
    this.clienteService.buscarCliente(this.celular).subscribe(cliente => {
      debugger;
      this.cliente = cliente;
      this.nombreCliente = this.cliente[0].nombreCliente;
      this.cargando = false;
      if(this.cliente) {
        this.clienteEncontrado = true;
      } else {
        this.clienteEncontrado = false;
      }
    });

    this.productosCarrito.forEach(producto => {
        this.valorCompra += producto.valorUnitario;
    });
  }

}
