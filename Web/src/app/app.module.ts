import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { RouterModule, Routes} from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule, MatInputModule } from '@angular/material';
import { HttpClientModule } from '@angular/common/http';

import { AlertModule } from 'ngx-bootstrap';
import { BookService } from './Book.service';

import { AppComponent } from './app.component';
import { MainpageComponent } from './mainpage/mainpage.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { BookaddComponent } from './Bookadd/Bookadd.component';
import { BooklistComponent } from './Booklist/Booklist.component';
import { ErrorInterceptorProvider } from './http.interceptor';

const appRoutes: Routes = [
  { path: '', component: MainpageComponent },
  { path: 'mainpage', component: MainpageComponent },
  { path: 'Booklist', component: BooklistComponent },
  { path: 'Bookadd', component: BookaddComponent },
  { path: 'Bookadd/:id', component: BookaddComponent },
  // otherwise redirect to home
  {path: '**', redirectTo: ''}
];

@NgModule({
  declarations: [
    AppComponent,
    MainpageComponent,
    HeaderComponent,
    FooterComponent,
    BookaddComponent,
    BooklistComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    HttpClientModule,
    MatTableModule,
    MatInputModule,
    AlertModule.forRoot()
  ],
  providers: [BookService, ErrorInterceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
