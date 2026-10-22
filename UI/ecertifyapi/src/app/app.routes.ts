import { Routes } from '@angular/router';
import { About } from './pages/about/about';
import { Home } from './components/home/home';
import { DataBinding } from './components/basics/data-binding/data-binding';

export const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: Home },
  { path: 'about', component: About },
  { path: 'examples/data-binding', component: DataBinding }
];
