import { Component, Input, OnInit } from '@angular/core';
import { Task } from '../shared/models/task';
import { TaskService } from '../core/services/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { error } from 'console';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.css'
})
export class TaskFormComponent implements OnInit {
  @Input() isEditMode = false;
  task: Task = {id: "", name: "", description: "", type: "", created: null, status: "New"};
  taskStatuses = [
    { value: 'New', label: 'New' },
    { value: 'InProgress', label: 'In Progress' },
    { value: 'Completed', label: 'Completed' },
    { value: 'OnHold', label: 'On Hold' },
    { value: 'Cancelled', label: 'Cancelled' }
  ];
  taskTypes = ['Bug', 'Feature', 'Improvement', 'Research'];
  // isEditMode = false;

  constructor(private taskService: TaskService, private route: ActivatedRoute, public router: Router){}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("id");
    if (id) {
      this.isEditMode = true;
      this.taskService.getTaskById(id).subscribe({
        next: (task) => (this.task = task),
        error: (err) => console.error(err),
      })
    }
  }

  onSubmit() {
    if(this.isEditMode) {
      this.taskService.updateTask(this.task.id, this.task).subscribe({
        next: () => this.router.navigate(['/tasks']),
        error: (err) => console.error(err),
      });
    } else {
      this.taskService.createTask(this.task).subscribe({
        next: () => this.router.navigate(['/tasks']),
        error: (err) => console.error(err),
      });
    }
  }

}
