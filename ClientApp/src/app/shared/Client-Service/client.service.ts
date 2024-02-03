import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment.development";

import {HttpClient} from "@angular/common/http";
import {Client} from "./client.model";

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  url:string = environment.apiBaseurl+ '/Clients'
  list:Client[] = []
  client : Client = new Client()
  constructor(private http: HttpClient) { }
  postClient(){
    return this.http.post(this.url,this.client).subscribe({
      next : res => {console.log(res)},
      error : err => {console.log(err)}
    })
  }
}
