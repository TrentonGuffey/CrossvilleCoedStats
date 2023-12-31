import React, { useState } from 'react';
import rules from '../CrossvilleCo-edSoftballRules2023.pdf';
import { SpecialZoomLevel, Worker } from '@react-pdf-viewer/core';
import { Viewer } from '@react-pdf-viewer/core';
import '@react-pdf-viewer/core/lib/styles/index.css';

const pdfjs = await import('pdfjs-dist/build/pdf');
const pdfjsWorker = await import('pdfjs-dist/build/pdf.worker.entry');

pdfjs.GlobalWorkerOptions.workerSrc = pdfjsWorker;

export default function Rules() {

  

  return (
    <div
      style={{
        border: '1px solid rgba(0, 0, 0, 0.3)',
        height: '750px',
        width: '650px'
      }}
    >
      <Worker workerUrl="https://unpkg.com/pdfjs-dist@3.4.120/build/pdf.worker.min.js">
        <Viewer fileUrl={rules} defaultScale={SpecialZoomLevel.ActualSize} />;
      </Worker>
    </div>
  )
};

