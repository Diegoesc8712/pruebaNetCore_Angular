import { Token } from '@angular/compiler';
import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserI } from 'src/app/models/user';
import { FormGroup } from '@angular/forms';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  constructor(private AuthService: AuthService, private router: Router){}

  ngOnInit(): void {
      
  }

  async onLogin(form: NgForm){
    debugger;
    this.AuthService.login(form.value).subscribe(res=>{
      //this.router.navigate(['/login']);
    })
  }

}
