import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserI } from '../models/user';
import { JwtResponseI } from './../models/jwt-response';
import { tap } from 'rxjs/operators';
import { Observable, BehaviorSubject } from 'rxjs'; 
import { Token } from '@angular/compiler';



@Injectable()
export class AuthService {
  AUTH_SERVER: string = 'https://localhost:7262';
  authSubject = new BehaviorSubject(false);
  private token: string = "";
  constructor(private HttpClient: HttpClient) { }

  register(user:UserI):Observable<JwtResponseI>{
     return this.HttpClient.post<JwtResponseI>(`${this.AUTH_SERVER}/register`, user).pipe(tap(
        (res:JwtResponseI)=>{
          debugger;
          if(res){
            //Guardar token
            this.saveToken(res.dataUser.accessToken, res.dataUser.expiresIn)
          }
        })
      ); 
    }


    login(user:UserI):Observable<JwtResponseI>{
      debugger;

      
      this.HttpClient.post(`${this.AUTH_SERVER}/login`, user).subscribe(
        function (result) {
          debugger;
          console.log(result);
          //resolve(_this.parseResultPetition(result));
        }
      )

          


      return this.HttpClient.post<JwtResponseI>(`${this.AUTH_SERVER}/login`, 
        user).pipe(tap(
         (res:JwtResponseI)=>{
          debugger;
          console.log(res);
           if(res){
             //Guardar token
             debugger;
             this.saveToken(res.dataUser.accessToken, res.dataUser.expiresIn)
           }
         })
       ); 
     }


    logout():void{
      this.token = '';
      localStorage.removeItem("ACCESS_TOKEN");
      localStorage.removeItem("EXPIRES_IN");
     }

     private saveToken(token:string, expireIn: string): void{
      localStorage.setItem("ACCESS_TOKEN", token);
      localStorage.setItem("EXPIRES_IN", expireIn);
      this.token = token;
     }

     private getToken():string{
        if(!this.token){
          //this.token = localStorage.getItem("ACCESS_TOKEN");
        }
        return this.token;
     }
}
