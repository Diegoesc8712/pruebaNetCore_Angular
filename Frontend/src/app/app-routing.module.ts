import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuariosListComponent } from './usuarios-list/usuarios-list.component';
import { ProductosListComponent } from './productos-list/productos-list.component';
import { ComprasComponent } from './compras/compras.component';

const routes: Routes = [
  { path: '', redirectTo:'/auth', pathMatch:'full' },
  { path: 'auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) },
  {path: 'usuariosList', component: UsuariosListComponent},
  {path: 'productosList', component: ProductosListComponent},
  {path: 'compras', component: ComprasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
