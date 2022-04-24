import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { PaginatedResult } from 'src/app/models/pagination';
import { TaskModel } from 'src/app/models/taskModel';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) { }

  apiTask=environment.baseUrl+'/task';

  paginatedResult:PaginatedResult<TaskModel[]>= new PaginatedResult<TaskModel[]>();

  queryParams:HttpParams;

  private  createParams(page: number, itemsPerPage: number,orderBy:string)
  {
    this.queryParams=new HttpParams();
    this.queryParams = this.queryParams.append("pageNumber",page.toString());
    this.queryParams = this.queryParams.append("pageSize",itemsPerPage.toString()); 
    this.queryParams = this.queryParams.append("orderBy",orderBy); 
  }
  
  getAllTasks(page?: number, itemsPerPage?: number,orderBy?:string):Observable<PaginatedResult<TaskModel[]>>
  {

    if(page!=null && itemsPerPage!=null&&orderBy!=null)
      this.createParams(page,itemsPerPage,orderBy)

    return this.http.get<TaskModel[]>(this.apiTask,{observe:'response',params:this.queryParams }).pipe( 
      map(response=>{
        this.paginatedResult.result=response.body;
        if(response.headers.get('Pagination')!=null)
        this.paginatedResult.pagination=JSON.parse(response.headers.get('Pagination'))
        return this.paginatedResult;
      }

      )
    ) 
  }

  getTaskById(id:number):Observable<TaskModel> {

    return this.http.get<TaskModel>(this.apiTask+"/GetTaskById/"+id);
  }

  addTask(task:TaskModel):Observable<boolean>
  {  
    return this.http.post<boolean>(this.apiTask+"/AddTask",task); 
  }

  deleteTask(id:number,page?: number, itemsPerPage?: number,orderBy?:string):Observable<PaginatedResult<TaskModel[]>>
  {
    if(page!=null && itemsPerPage!=null)
      this.createParams(page,itemsPerPage,orderBy)
   
    return this.http.get<TaskModel[]>(this.apiTask+"/DeleteTask/"+id,{observe:'response',params:this.queryParams }).pipe( 
      map(response=>{
        this.paginatedResult.result=response.body;
        if(response.headers.get('Pagination')!=null)
        this.paginatedResult.pagination=JSON.parse(response.headers.get('Pagination'))
        return this.paginatedResult;
      }

      ) 
    )
  }

  updateTask(id:number,taskCompleted:boolean):Observable<boolean>
  {
    return this.http.put<boolean>(this.apiTask+"/UpdateTask/"+id,taskCompleted); 
  }
 
}
