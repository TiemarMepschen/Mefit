import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminPage } from "./pages/admin/admin.page";
import { DashboardPage } from "./pages/dashboard/dashboard.page";
import { ProgramsPage } from "./pages/programs/programs.page";
import { ProfilePage } from "./pages/profile/profile.page";
import { AdminResolverService } from "./services/admin-resolver.service";
import { AuthGuard } from "./utils/app.guard";
import { GoalResolverService } from "./services/goal-resolver.service";
import { GoalWorkoutResolverService } from "./services/goal-workout-resolver.service";
import { GoalProgramService } from "./services/goal-program-resolver.service";
import { UserResolverService } from "./services/user-resolver.service";

const routes: Routes = [
    {
        path: "",
        pathMatch: "full",
        redirectTo: "/dashboard"
    },
    {
        path: "dashboard",
        component: DashboardPage,
        resolve: {
            goal: GoalResolverService,
            workouts: GoalWorkoutResolverService,
            program: GoalProgramService
        },
        canActivate: [ AuthGuard ]
    },
    {
        path: "programs",
        component: ProgramsPage,
        canActivate: [ AuthGuard ],
        resolve: {
            goal: GoalResolverService,
            workouts: GoalWorkoutResolverService,
            program: GoalProgramService
        }
    },
    {
        path: 'profile',
        component: ProfilePage,
        canActivate: [ AuthGuard ]
    },
    {
        path: 'admin',
        component: AdminPage,
        resolve: { 
            admin: AdminResolverService,
            user: UserResolverService      
        },
        canActivate: [ AuthGuard ]
    }
]
@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule {

}