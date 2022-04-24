import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/models/pagination';
import { TaskModel } from 'src/app/models/taskModel';
import { TaskService } from 'src/app/services/taskService/task.service';

@Component({
  selector: 'app-tasks-list',
  templateUrl: './tasks-list.component.html',
  styleUrls: ['./tasks-list.component.css']
})
export class TasksListComponent implements OnInit {

  constructor(private tservice: TaskService) { }

  tasksList: TaskModel[];
  itemsPerPage = 5;
  pagination:Pagination;
  orderBy='date'

  ngOnInit(): void {
    
    this.getAllTasks(0)
  }

  sortBy(value:string)
  {
    this.orderBy=value
    this.getAllTasks(0)
  }
  getAllTasks(page: number) {

    this.tservice.getAllTasks(page, this.itemsPerPage,this.orderBy).subscribe(

      data => {
        console.log(data),
        this.tasksList = data.result,
        this.pagination = data.pagination
      },
      err => { console.log('error ' + err) }
    )
  }

  deleteTask(id: number, page: number) {
    this.tservice.deleteTask(id, page, this.itemsPerPage,this.orderBy).subscribe(
      data => {
        console.log('Successfully deleted')
        this.tasksList = data.result,
          this.pagination = data.pagination
      },
      err => console.log('error ' + err)

    )
  }

  update(id: number, tCompleted: boolean) {
    this.tservice.updateTask(id, tCompleted).subscribe(
      data => console.log('update successfully'),
      err => console.log(err)
    )

  }
   
}


