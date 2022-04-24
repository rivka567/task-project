import { Time } from "@angular/common";

export interface TaskModel{
   taskName:string,
   taskTypeId:number,
   taskType?:string,
   repeatTask:boolean,
   taskTime:string,
   dateCompleted:string,
   taskCompleted?:boolean,
   describeTask?:string
} 