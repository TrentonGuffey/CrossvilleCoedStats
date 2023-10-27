import React, { useState } from 'react';
import { SpecialZoomLevel, Worker } from '@react-pdf-viewer/core';
import { Viewer } from '@react-pdf-viewer/core';

import waiver from '../CoedLeagueWaiverUpdated2022.pdf';

const pdfjs = await import('pdfjs-dist/build/pdf');
const pdfjsWorker = await import('pdfjs-dist/build/pdf.worker.entry');

pdfjs.GlobalWorkerOptions.workerSrc = pdfjsWorker;


export default function Waiver() {

  return (
    <div className='waiver'
      style={{
        border: '1px solid rgba(0, 0, 0, 0.3)',
        height: '750px',
        width: '650px',
      }}
    >
      <Worker workerUrl="https://unpkg.com/pdfjs-dist@3.4.120/build/pdf.worker.min.js">
        <Viewer fileUrl={waiver} defaultScale={SpecialZoomLevel.ActualSize} />;
      </Worker>
    </div>

  );
}

