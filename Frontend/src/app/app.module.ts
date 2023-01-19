import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthRoutingModule } from './auth/auth-routing.module';
import { AuthService } from './services/auth.service';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from './auth/auth.module';
import { UsuariosListComponent } from './usuarios-list/usuarios-list.component';
import { ProductosListComponent } from './productos-list/productos-list.component';
import { FormsModule } from '@angular/forms';
import { ComprasComponent } from './compras/compras.component';

@NgModule({
  declarations: [
    AppComponent,
    UsuariosListComponent,
    ProductosListComponent,
    ComprasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthRoutingModule,
    HttpClientModule,
    AuthModule,
    FormsModule
    
  ],
  providers: [ AuthService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
