import { Component, OnInit } from '@angular/core';
import { Task } from '../shared/models/task';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TaskService } from '../core/services/task.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  providers: [TaskService],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent implements OnInit {
  tasks: Task[] = [];

  constructor(private taskService: TaskService, private router: Router) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  getStatusLabel(status: string): string {
    const statusMap: { [key: string]: string } = {
      New: 'New',
      InProgress: 'In Progress',
      Completed: 'Completed',
      OnHold: 'On Hold',
      Cancelled: 'Cancelled'
    };
    return statusMap[status] || status;
  }

  loadTasks(): void {
    this.taskService.getTasks().subscribe({
      next: data => {
        console.log('Tasks received:', data);
        this.tasks = data;
      },
      error: err => console.error('Error loading tasks:', err)
    });
  }

  deleteTask(id: string): void{
    this.taskService.deleteTask(id).subscribe(() => {
      this.loadTasks();
    });
  }

  editTask(id: string): void{
    this.router.navigate(['/tasks', id, 'edit']);
  }

  viewDetails(id: string): void{
    this.router.navigate(['/tasks', id]);
  }

}
