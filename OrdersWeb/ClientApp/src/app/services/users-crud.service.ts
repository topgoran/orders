import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { map } from 'rxjs/operators';
import { PaginatedUsers } from '../models/PaginatedUsers';
import { User } from '../models/User';
import { UserDTO } from '../models/UserDTO';

const UPDATE = gql`
  mutation($user: userInput!, $userId: ID!){
    updateUser(user: $user, userId: $userId){
      id
      firstName
      lastName
      userName
      email
      city
      state
      address
    }
  }
`;

const REGISTER = gql`
mutation($user:userInput!){
  registerMember(user: $user){
    success
  }
}
`;

const DELETE = gql`
mutation($userId: ID!){
  deleteUser(userId: $userId)
}
`

const GET_USER = gql`
query($id: ID!){
  user(id: $id){
    id
    firstName
    lastName
    userName
    email
    city
    state
    address
  }
}
`

const GET_USERS = gql`
  query usersCustom($pageSize: Int!, $pageNumber: Int!) {
    usersCustom(pageSize: $pageSize, pageNumber: $pageNumber){
      users{
        id
        firstName
        lastName
        userName
        email
        city
        state
        address
      }
      count
    }
  }`;

  const GET_USERS_FILTER = gql`
  query usersCustom($pageSize: Int!, $pageNumber: Int!, $filter: String!) {
    usersCustom(pageSize: $pageSize, pageNumber: $pageNumber, filter:$filter){
      users{
        id
        firstName
        lastName
        userName
        email
        city
        state
        address
      }
    count
    }
  }
  `

@Injectable({
  providedIn: 'root'
})

export class UsersCrudService {
  userToUpdate!: User;
  clickedRow!: UserDTO;
  query: any
  

  queryParams : any;

  constructor(private apollo: Apollo) {}

  getUsers(pageSize: number, pageNumber: number, filter: string){
    return this.apollo.watchQuery<PaginatedUsers>({
      query: GET_USERS_FILTER,
      fetchPolicy: 'network-only',
      variables: {
        pageSize,
        pageNumber,
        filter
      },
    }).valueChanges
  }

  create(user: User) {
    return this.apollo.mutate({
      mutation: REGISTER,
      variables: {
        user
      },
      optimisticResponse: {
        registerMember: {
          success: 'Boolean'
        }
      },
    });
  }

  update(user: User, userId: string) {
    return this.apollo.mutate({
      mutation: UPDATE,
      variables: {
        user,
        userId
      },
      optimisticResponse: {
        userName: 'String',
        firstName: 'String',
        lastName: 'String',
        email: 'String',
        city: 'String',
        state: 'String',
        address: 'String'
      },
    });      
    }

  delete(userId: string, postsPerPage: number, pageNumber: number) {
    this.queryParams = {
      pageSize: postsPerPage,
      pageNumber: pageNumber
    }

    console.log("delete",postsPerPage, pageNumber)
   return this.apollo.mutate({
      mutation: DELETE,
      refetchQueries:[{query: GET_USERS, variables: this.queryParams}],
      variables: {
        userId
      },
    });      
  }

  getUser(id: string){
    return this.apollo.watchQuery({
      query: GET_USER,
        variables: {
          id: id
        },
      }).valueChanges.pipe(map((result: any) => result.data && result.data.user))
    }
}
