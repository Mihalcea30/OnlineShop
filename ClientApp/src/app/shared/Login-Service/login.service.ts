import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment.development";
import {Login} from "./login.model";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Token} from "./token.model";
import {jwtDecode} from "jwt-decode";
import {Products} from "../Product-Service/products.model";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url:string = 'https://localhost:7299/login'
  credentials: Login = new Login()
  token : Token = new Token()
  roleurl1:string = environment.apiBaseurl + '/isSeller'
  roleurl2:string = environment.apiBaseurl + '/isClient'
  role : string = ""
  constructor(private http : HttpClient) { }
  postLogin(){
    return this.http.post(this.url, this.credentials).subscribe(
      {next:res => {console.log(res);
          //const decodedToken = jwtDecode('Bearer ' + this.token.accessToken);
          //console.log(decodedToken);
          this.token = res as Token;
          const headers = new HttpHeaders().set('Authorization', `Bearer ${this.token.accessToken}`);
          this.http.get(this.roleurl1,{headers}).subscribe({
            next:res => {this.role = "seller"}
          })
          this.http.get(this.roleurl2, {headers}).subscribe({
            next:res => {this.role = "client"}
          })
          if(this.role == "seller")
          {
            localStorage.setItem('token',this.token.accessToken);
            localStorage.removeItem('token2')
          }
          else
          {
            localStorage.setItem('token2', this.token.accessToken)
            localStorage.removeItem('token')
          }

        },
      error: err => {console.log(err)}}
    )
  }
  checkRoles(){
    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.token.accessToken}`);
    this.http.get(this.roleurl1,{headers}).subscribe({
      next:res => {console.log(res)}
    })
    this.http.get(this.roleurl2, {headers}).subscribe({
      next:res => {console.log(res)}
    })
  }
  gainAuthorization(){

      // Retrieve token from localStorage
      const token = localStorage.getItem('token');

      // Include token in the Authorization header
      const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

      // Make the API request with the token included in the headers
      return this.http.get<any>(`${this.url}/protected-endpoint`, { headers });
  }
  isLoggedIn(): boolean {

    return (localStorage.getItem('token') != null || localStorage.getItem('token2') != null);
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('token2');
  }
}
