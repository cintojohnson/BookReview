import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { BookReviews: [], loading: true };
    }

    componentDidMount() {
        this.populateBookReviewData();
    }

    static renderTopAuthor(bookReviews) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <tr>
                    <td>
                        The top writer by average rating is <b>{bookReviews[0].author}</b> and the rating is <b>{bookReviews[0].averageRating}.</b>
                    </td>
                </tr>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. </em></p>
            : App.renderTopAuthor(this.state.BookReviews);

        return (
            <div>
                <h1 id="tabelLabel" >Book Reviews - Top Writer</h1>
                {contents}
            </div>
        );
    }

    async populateBookReviewData() {
        const response = await fetch('BookReviews');
        const data = await response.json();
        this.setState({ BookReviews: data, loading: false });
    }
}
