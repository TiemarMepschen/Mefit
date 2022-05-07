export interface User{
    id: number;
    firstName: string;
    lastName: string;
    keycloakId: string;
    isAdmin: number;
    profile: Profile;
}

export interface Profile{
    id: number,
    goalId: number;
    currentGoalId: number;
    userId: number;
}