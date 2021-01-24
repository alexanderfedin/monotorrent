﻿//
// StandardPicker.cs
//
// Authors:
//   Alan McGovern alan.mcgovern@gmail.com
//
// Copyright (C) 2006 Alan McGovern
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//


using System.Collections.Generic;

using MonoTorrent.Client.Messages.Standard;

namespace MonoTorrent.Client.PiecePicking
{
    /// <summary>
    /// Allows an IPiecePicker implementation to create piece requests for
    /// specific peers and then add them to the peers message queue. If the
    /// limits on maximum concurrent piece requests are ignored
    /// </summary>
    public interface IManualPieceRequest
    {
        /// <summary>
        /// Enqueues a <see cref="RequestMessage"/> in the peer's message queue.
        /// Typically used when manually invoke <see cref="IPiecePicker.ContinueAnyExistingRequest(IPeer, int, int, int)"/>,
        /// <see cref="IPiecePicker.ContinueExistingRequest(IPeer, int, int)"/> or
        /// <see cref="IPiecePicker.PickPiece(IPeer, BitField, IReadOnlyList{IPeer}, int, int, int)"/>
        /// </summary>
        /// <param name="peer"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        void EnqueuePieceRequest (IPeer peer, PieceRequest request);

        /// <summary>
        /// Enqueues a <see cref="CancelMessage"/> in the peer's message queue.
        /// This is typically used to send cancel messages for each <see cref="PieceRequest" />
        /// returned by <see cref="IPiecePicker.CancelRequests(IPeer, int, int)"/>
        /// </summary>
        /// <param name="peer">The peer to send the <see cref="CancelMessage"/> to</param>
        /// <param name="request">The piece request to cancel.</param>
        void EnqueueCancelRequest (IPeer peer, PieceRequest request);
    }
}