import { getGreeting } from '../support/app.po';

describe('editor', () => {
  beforeEach(() => cy.visit('/'));

  it('should display welcome message', () => {
    getGreeting().contains('Welcome to editor!');
  });
});
