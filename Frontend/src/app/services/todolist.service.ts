import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Subject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { TodoItemModel } from '../models/todoitem.model';

@Injectable({
    providedIn: 'root'
})
export class TodoListService {
    public itemsChanged = new Subject<TodoItemModel[]>();
    public todoItems: TodoItemModel[] = [];

    constructor(private httpClient: HttpClient) {
        this.reload();
    }

    public reload(){
        this.httpClient.get<TodoItemModel[]>(`${environment.apiUrl}/api/todo`).subscribe((list) => {
            this.todoItems = list;
            this.itemsChanged.next(list);
        });
    }

    public get(todoItemId: number): TodoItemModel {
        return this.todoItems.find(x => x.id === todoItemId);
    }

    public changeStatus(todoItem: TodoItemModel): Observable<TodoItemModel> {
      const baseSaveUrl = `${environment.apiUrl}/api/todo/${todoItem.id}/status`;

      return this.httpClient.put<TodoItemModel>(`${baseSaveUrl}`, todoItem)
          .pipe(tap(updatedTodoItem => {
              const index = this.todoItems.findIndex(item => item.id == updatedTodoItem.id);
              this.todoItems[index].done = updatedTodoItem.done;
          }));
    }

    public save(todoItem: TodoItemModel): Observable<TodoItemModel> {
        const baseSaveUrl = `${environment.apiUrl}/api/todo`;

        if (todoItem.id) {
            return this.httpClient.put<TodoItemModel>(`${baseSaveUrl}`, todoItem)
                .pipe(tap(updatedTodoItem => {
                    todoItem = updatedTodoItem;
                }));
        } else {
            return this.httpClient.post<TodoItemModel>(`${baseSaveUrl}`, todoItem)
                .pipe(tap(insertedTodoItem => {
                    this.todoItems.push(insertedTodoItem);
                }));
        }
    }

    public delete(todoItemId: number) {
        return this.httpClient.delete<TodoItemModel[]>(`${environment.apiUrl}/api/todo/${todoItemId}`).subscribe((list) => {
            const todoItemToRemove = this.get(todoItemId);
            this.todoItems.splice(this.todoItems.indexOf(todoItemToRemove), 1);
        });
    }
}
