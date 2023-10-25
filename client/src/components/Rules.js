import React, { useState } from 'react';
import { Document, Page } from 'react-pdf';

export default function PdfViewer() {
    const [numPages, setNumPages] = useState(null);
    const [pageNumber, setPageNumber] = useState(1);

    const onDocumentLoadSuccess = ({ numPages }) => {
        setNumPages(numPages);
    };

    const handlePageChange = newPageNumber => {
        setPageNumber(newPageNumber);
    };

    return (
        <div>
            <Document
                file="/SpecificCrossvilleCo-edSoftbalRules2023.pdf"
                onLoadSuccess={onDocumentLoadSuccess}
            >
                <Page
                    pageNumber={pageNumber}
                    width={600}
                />
            </Document>
            <div>
                <p>
                    Page {pageNumber} of {numPages}
                </p>
                <button onClick={() => handlePageChange(pageNumber - 1)} disabled={pageNumber <= 1}>Previous</button>
                <button onClick={() => handlePageChange(pageNumber + 1)} disabled={pageNumber >= numPages}>Next</button>
            </div>
        </div>
    );
}
    