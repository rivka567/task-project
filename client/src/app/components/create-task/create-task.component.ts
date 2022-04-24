import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TaskService } from 'src/app/services/taskService/task.service';
import { Router } from '@angular/router';
import { Time } from '@angular/common';
import { TypeService } from 'src/app/services/typeService/type.service';
import { TaskModel } from 'src/app/models/taskModel';
import { TypeModel } from 'src/app/models/typeModel';
import { format } from 'date-fns';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {

  constructor(private fb:FormBuilder,private tService:TaskService,private router:Router,private tyService:TypeService) { }
  
  form: FormGroup;
  task:TaskModel;
  minDate:Date;
  types:TypeModel[];

  ngOnInit(): void {

  this.tyService.getAllTypes().subscribe(
    data=>{this.types=data
    console.log(data);
    },
    err=>console.log(err)
   
  )

    this.minDate=new Date()   
    this.initForm()
  }


  initForm()
  {
    this.form = this.fb.group({
      taskName:['',Validators.required],
      taskType:['',Validators.required],
      repeatTask:[''||false],
      taskTime:['',Validators.required],
      dateCompleted:['',Validators.required],
      describeTask:['']
    })
  }



  create()
  {
    
    let formContent=this.form.value;

    this.task={
      taskName:formContent.taskName,
      dateCompleted:format(formContent.dateCompleted, 'yyyy-MM-dd'),
      repeatTask:formContent.repeatTask,
      taskTime:format(formContent.taskTime, 'HH:mm'),
      taskTypeId:formContent.taskType.id,
      taskCompleted:false

    };
  
     this.tService.addTask(this.task).subscribe(

       data=>{console.log('add successfully');
       this.router.navigateByUrl('tasks-list')
      },
       err=>console.log(err)
     )
     
  }
}
