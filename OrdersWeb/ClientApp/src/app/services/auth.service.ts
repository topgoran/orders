import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Apollo, Mutation, gql } from "apollo-angular";
import { User } from 'src/app/models/User';

const LOG_IN = gql`
  mutation loginUser($username: String!, $password: String!) {
    loginUser(username: $username, password: $password) {
    token
    id
    userName
    email
    firstName
    lastName
    address
    city
    state
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

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(private apollo: Apollo) {}

  logIn(username: string, password: string) {
    return this.apollo.mutate({
      mutation: LOG_IN,
      variables: {
        username,
        password
      },
      optimisticResponse: {
        __typename: 'Mutation',
        loginUser: {
          id: 'String',
          token: 'String',
          userName: 'String',
          email: 'String',
          firstName: 'String',
          lastName: 'String',
          address: 'String',
          city: 'String',
          state: 'String'
        },
      },
    });
  }

  register(user: User) {
    return this.apollo.mutate({
      mutation: REGISTER,
      variables: {
        user
      },
      optimisticResponse: {
        registerMember:{
          __typename:	'RegistrationResponseType',
          success: 'Boolean'
        }
      },
    });
  }
}
