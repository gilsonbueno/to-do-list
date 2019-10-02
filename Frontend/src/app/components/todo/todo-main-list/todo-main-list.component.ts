import { OnInit, Component, OnDestroy } from '@angular/core';
import { TodoItemModel } from 'src/app/models/todoitem.model';
import { TodoListService } from 'src/app/services/todolist.service';
import { TodoEditComponent } from '../todo-edit/todo-edit.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-todo-main-list',
  templateUrl: './todo-main-list.component.html',
  styleUrls: ['./todo-main-list.component.less']
})
export class TodoMainListComponent implements OnInit, OnDestroy {
  private itemsChanged: Subscription;
  public todoItems: TodoItemModel[] = [];

  constructor(private todoListService: TodoListService, private modalService: NgbModal) { }

  ngOnInit() {
    this.todoItems = this.todoListService.todoItems;

    this.itemsChanged = this.todoListService.itemsChanged.subscribe((todoItems) => {
      this.todoItems = todoItems;
    });
  }

  ngOnDestroy(): void {
    this.itemsChanged.unsubscribe();
  }

  public onEdit(todoItemId: number): void {
    this.openEditPopup(todoItemId);
  }

  public onAdd(): void {
    this.openEditPopup(null);
  }

  public onDelete(todoItemId: number): void {
    this.todoListService.delete(todoItemId);
  }

  public onChangeStatus(todoItem: TodoItemModel): void {
    this.todoListService.changeStatus(todoItem).subscribe(() => {
      this.todoListService.reload();
    });
  }

  private openEditPopup(todoItemId: number) {
    const modalRef = this.modalService.open(TodoEditComponent);
    const component = <TodoEditComponent>modalRef.componentInstance;
    component.registerToEdit.next(todoItemId);
  }
}
