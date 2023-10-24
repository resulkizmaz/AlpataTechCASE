import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DefaultComponent } from './home/default/default.component';
import { SignUpComponent } from './home/default/sign-up/sign-up.component';
import { HomePageComponent } from './home/default/home-page/home-page.component';
import { LogInComponent } from './home/default/log-in/log-in.component';



@NgModule({
  imports: [RouterModule.forRoot(AppRoutingModule.getRoutes())],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor() {}

  public static getRoutes(){
    const routes: Routes = [
      {
        path:'',
        component: DefaultComponent,
        children: [{
          path:'',
          component:LogInComponent,
          children:[{
            path:'home',
            component: HomePageComponent
          },{
            path:'log-in',
            component: DefaultComponent
          }]
        },{
          path: 'sign-up',
          component:SignUpComponent
        }]
      }





    ];
    return routes;
  }


 }
