import { CustomerService } from './services/customer.service';
import { MovieService } from './services/movie.service';
import { RentalService } from './services/rental.service';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { AccountLoginComponent } from './components/account-login/account-login.component';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { CustomerFormComponent } from './components/customer-form/customer-form.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { RentalFormComponent } from './components/rental-form/rental-form.component';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        AccountLoginComponent,
        CustomerListComponent,
        CustomerFormComponent,
        MovieListComponent,
        RentalFormComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'account/login', component: AccountLoginComponent },
            { path: 'customers', component: CustomerListComponent },
            { path: 'customers/new', component: CustomerFormComponent },
            { path: 'movies', component: MovieListComponent },
            { path: 'rentals/new', component: RentalFormComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        CustomerService,
        MovieService,
        RentalService]   
})
export class AppModule {
}
