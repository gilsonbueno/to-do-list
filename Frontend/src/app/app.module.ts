import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';
import { TodoMainListComponent } from './components/todo/todo-main-list/todo-main-list.component';
import { TodoEditComponent } from './components/todo/todo-edit/todo-edit.component';
import { ErrorComponent } from './components/error/error.component';
import { ErrorInterceptor } from './services/error.interceptor';
import { TodoListService } from './services/todolist.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    TodoMainListComponent,
    TodoEditComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    TodoListService
  ],
  entryComponents: [TodoEditComponent, ErrorComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }