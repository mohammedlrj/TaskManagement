import { Routes } from '@angular/router';
import { TaskListComponent } from './task-list/task-list.component';
import { TaskFormComponent } from './task-form/task-form.component';
import { TaskDetailsComponent } from './task-details/task-details.component';

export const routes: Routes = [
    { path: 'tasks', component: TaskListComponent },
    { path: 'tasks/new', component: TaskFormComponent },
    { path: 'tasks/:id/edit', component: TaskFormComponent },
    { path: 'tasks/:id', component: TaskDetailsComponent },
    { path: '', redirectTo: '/tasks', pathMatch: 'full' },
    { path: '**', redirectTo: '/tasks' }
];
