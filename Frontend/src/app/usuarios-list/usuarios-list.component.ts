import { UserI } from 'src/app/models/user';
import { ViewChildren, Component, OnInit, QueryList } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UsuariosListService } from '../services/usuarios-list.service';
import { Usuario } from '../models/usuario';

@Component({
  selector: 'app-usuarios-list',
  templateUrl: './usuarios-list.component.html',
  styleUrls: ['./usuarios-list.component.css']
})
export class UsuariosListComponent implements OnInit{
  usuarios: Usuario[] = [];
  constructor(private UsuariosListService: UsuariosListService, private router: Router){}

    ngOnInit(): void {
      this.UsuariosListService.usuariosLista().subscribe(usuarios => this.usuarios = usuarios);
  }
}

