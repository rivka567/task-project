import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TypeModel } from 'src/app/models/typeModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TypeService {

  constructor(private http: HttpClient) { }

  apiTask=environment.baseUrl+'/type';


  getAllTypes():Observable<TypeModel[]>{

    return this.http.get<TypeModel[]>(this.apiTask);

  }
}
