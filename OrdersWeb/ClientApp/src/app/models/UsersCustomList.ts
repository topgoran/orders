import { UserPageDAO } from "./UserPageDAO";

export interface UsersCustomList{
    users: UserPageDAO[];
    count: number;
}