// https://docs.cypress.io/api/introduction/api.html

describe('My First Test', () => {
  it('Visits the app root url', () => {
    cy.visit('/')
    cy.contains('h1', 'Love Pizza, Vote for Pizza')
    cy.contains('.navbar-brand', 'Love Pizza')
    cy.contains('.nav-link', 'Login')
    cy.contains('.alert', 'Please login in order to be able to vote.')
    cy.get('[alt="Love Pizza, Vote for Pizza"]')
        .should('be.visible')
        .and(($img) => {
          expect($img[0].naturalWidth).to.be.greaterThan(0)
        })
    cy.get('#bar-chart')
        .should('be.visible')
  })
})
