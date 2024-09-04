import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeComponentComponent } from './welcome-component/welcome-component.component';
import { AboutComponent } from './about/about.component';
import { SendMoneyComponent } from './send-money/send-money.component';
import { TransaccionComponent } from './transaccion/transaccion.component';
import { RegistroComponent } from './registro/registro.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProfileComponent } from './profile/profile.component';
import { ContactsTableComponent } from './contacts-table/contacts-table.component';
import { AuthGuard } from './guardas/auth.guard';

const routes: Routes = [
  { path: '', component: LoginComponent, canActivate: [AuthGuard] },
  { path: 'about', component: AboutComponent, canActivate: [AuthGuard] },
  { path: 'registro', component: RegistroComponent },
  { path: 'login', component: LoginComponent },
  { path: 'send-money', component: SendMoneyComponent, canActivate: [AuthGuard] },
  { path: 'transaction-history', component: TransaccionComponent, canActivate: [AuthGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'welcome', component: WelcomeComponentComponent, canActivate: [AuthGuard] },
  { path: 'contactos', component: ContactsTableComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), FormsModule,
    ReactiveFormsModule],
  exports: [RouterModule],
})
export class AppRoutingModule { }
